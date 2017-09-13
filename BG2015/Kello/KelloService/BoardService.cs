using System;
using System.Collections.Generic;
using System.Linq;
using KelloData;
using KelloRepository.Contexts;
using KelloRepository.Interfaces;
using KelloRepository.Repositories;
using KelloServiceInterfaces;

namespace KelloService
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;

        public BoardService(IBoardRepository boardRepository)
        {
            _boardRepository = boardRepository;
        }

        public Board GetBoard(int id)
        {
            return (from b in _boardRepository.Entities
                    where b.Id == id
                    select b).FirstOrDefault();
        }

        public IList<Board> GetBoards()
        {
            return _boardRepository.Entities.ToList();
        }

        public int CreateBoard(string title)
        {
            var board = new Board {Title = title};
            _boardRepository.Create(board);
            _boardRepository.Save();
            return board.Id;
        }

        public int AddList(int boardId, string listName)
        {
            var board = GetBoard(boardId);
            var list = new KelloList {Title = listName};
            board.Lists.Add(list);
            _boardRepository.Save();
            return list.Id;
        }
    }
}