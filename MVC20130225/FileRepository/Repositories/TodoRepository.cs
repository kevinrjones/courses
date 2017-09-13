using System;
using SystemFileAdapter;
using Entities;
using FileSystemInterfaces;
using TodoRepository.Interfaces;

namespace FileRepository.Repositories
{
    public class TodoRepository : BaseFileRepository<Todo>, ITodoRepository
    {
        public TodoRepository(string path, IFileInfoFactory fileInfo, IDirectoryInfo directoryInfo)
            : base(path + "/todos", fileInfo, directoryInfo)
        {
        }

        protected override string GenerateFileName(Todo entity)
        {
            return GenerateFileName(entity.Id);
        }

        private string GenerateFileName(string id)
        {
            return string.Format("{0}/{1}.json", Path, id);
        }
    }
}