using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kello.ViewModels;
using KelloData;
using KelloRepository.Contexts;
using KelloRepository.Repositories;
using KelloService;
using KelloServiceInterfaces;

namespace Kello.Controllers
{
    public class BoardsController : Controller
    {
        private readonly IBoardService _service;
        public BoardsController(IBoardService service)
        {
            _service = service;
        }

        private List<BoardViewModel> GetBoards()
        {
            IList<Board> boards = _service.GetBoards();

            var boardsVM = new List<BoardViewModel>();
            foreach (var board in boards)
            {
                var boardvm = new BoardViewModel { Id = board.Id, Title = board.Title };
                boardsVM.Add(boardvm);
            }

            return boardsVM;
        } 

        // GET: Boards
        public ActionResult Index()
        {            
            // render a view
            return View(GetBoards());
        }

        [HttpGet]
        public ActionResult New()
        {
            return View(new CreateBoardViewModel());
        }

        [HttpPost]
        public ActionResult Create(CreateBoardViewModel createBoard)
        {
            if (!ModelState.IsValid)
            {
                return View("New", createBoard);
            }
            // add board to database
            _service.CreateBoard(createBoard.Title);
            return RedirectToAction("Index");
        }


    }
}