using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Rooms.Commands;
using Northwind.Application.Rooms.Models;
using Northwind.Application.Rooms.Queries;

namespace Northwind.WebUI.Controllers
{
    public class RoomsController : BaseController
    {
        // GET api/rooms/getall
        [HttpGet]
        public async Task<ActionResult<RoomListModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetRoomsQuery()));
        }

        // GET api/rooms/get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetailsModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetRoomDetailsQuery { RoomId = id }));
        }

        // GET api/rooms/get/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoomDetailsModel>> GetCalendar(int id)
        {
            return Ok(await Mediator.Send(new GetRoomCalendarQuery { RoomId = id }));
        }

        // POST api/rooms/create
        [HttpPost]
        public async Task<IActionResult> Create([FromBody]CreateRoomCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        // PUT api/rooms/update/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateRoomCommand command)
        {
            command.RoomId = id;
            await Mediator.Send(command);

            return NoContent();
        }

        // DELETE api/rooms/delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteRoomCommand { RoomId = id });

            return NoContent();
        }
    }
}
