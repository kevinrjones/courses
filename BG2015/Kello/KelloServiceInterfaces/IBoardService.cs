
using System.Collections;
using System.Collections.Generic;
using KelloData;

namespace KelloServiceInterfaces
{
    public interface IBoardService
    {
        Board GetBoard(int id);
        IList<Board> GetBoards();
        int CreateBoard(string title);
        int AddList(int boardId, string listName);
    }
}