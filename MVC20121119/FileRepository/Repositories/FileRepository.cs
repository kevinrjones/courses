using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using SystemFileAdapter;
using Entities;
using FileSystemInterfaces;
using Repository;
using Serialization;
using TodoRepository.interfaces;

namespace FileRepository.Repositories
{
    public class FileRepository : ITodoRepository
    {
        private readonly string _path;
        private readonly FileInfoFactory _fileInfoFactory;
        private readonly IDirectoryInfo _directoryInfo;

        //public FileRepository(string path, IDirectoryInfo directoryInfo)
        //    : this(path, new SystemFileInfoFactory(), directoryInfo)
        //{

        //}

        public FileRepository(string path, FileInfoFactory fileInfo, IDirectoryInfo directoryInfo)
        {
            _path = path;
            _fileInfoFactory = fileInfo;
            _directoryInfo = directoryInfo;
        }

        public void Dispose()
        {
        }

        public IQueryable<Todo> Entities
        {
            get
            {
                var entries = new List<Todo>();
                // ReSharper disable LoopCanBeConvertedToQuery
                foreach (var fileInfo in _directoryInfo.EnumerateFiles(_path, "*.json"))
                // ReSharper restore LoopCanBeConvertedToQuery
                {
                    Todo entry;
                    using (var stream = new StreamReader(fileInfo.Open(FileMode.Open)))
                    {
                        var json = stream.ReadToEnd();
                        entry = JsonSerializer.Deserialize<Todo>(json);
                    }
                    entries.Add(entry);
                }
                return entries.AsQueryable();
            }
        }
        public Todo New()
        {
            return new Todo();
        }

        public void Update(Todo entity)
        {
            var fileName = GenerateFileName(entity); 
            IFileInfo fileInfo = _fileInfoFactory.CreateFileInfo(fileName);
            try
            {
                using (var stream = fileInfo.Open(FileMode.Open))
                {
                    var json = entity.SerializeToString();
                    var bytes = Encoding.UTF8.GetBytes(json);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (IOException)
            {
                throw new RepositoryException(string.Format("Unable to find entry with filename: {0}", fileName));
            }
        }
        
        public void Create(Todo entity)
        {
            var fileName = GenerateFileName(entity);
            IFileInfo fileInfo = _fileInfoFactory.CreateFileInfo(fileName);

            try
            {
                using (var stream = fileInfo.Create())
                {
                    var json = entity.SerializeToString();
                    var bytes = Encoding.UTF8.GetBytes(json);
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch (IOException)
            {
                throw new RepositoryException(string.Format("Unable to create entry with filename: {0}", fileName));
            }
        }

        public void Delete(Todo entity)
        {
            var fileName = GenerateFileName(entity);
            IFileInfo fileInfo = _fileInfoFactory.CreateFileInfo(fileName);

            try
            {
                fileInfo.Delete();
            }
            catch (IOException)
            {
                throw new RepositoryException(string.Format("Unable to create entry with filename: {0}", fileName));
            }
        }

        private string GenerateFileName(Todo entity)
        {
            string fileName = string.Format("{0}/{1}.json", _path, entity.Id);
            return fileName;
        }
    }
}