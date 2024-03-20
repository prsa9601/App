using App.Infrastructure.Security;
using Common.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Role.Create;
using Shop.Application.Role.Delete;
using Shop.Application.Role.Update;
using Shop.Domain.RoleAgg.Enums;
using Shop.Presentation.Facade.Role;
using Shop.Query.Products.DTOs;
using Shop.Query.Roles.DTOs;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace App.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ApiController
    {
        private readonly IRoleFacade _facade;
        public RoleController(IRoleFacade facade)
        {
            _facade = facade;
        }

        // GET: api/<RoleController>
      
       // [Route("getId")]
        [HttpGet("{id}")]
        public async Task<ApiResult<RoleDto?>> GetId(long id)
        {
            var result = await _facade.GetRoleById(id);
            return QueryResult(result);
        }

        // GET api/<RoleController>/5
        [HttpGet]
        public async Task<ApiResult<List<RoleDto>>?> GetList()
        {
            var result = await _facade.GetRoles();
            return QueryResult(result);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ApiResult> Post(CreateRoleCommand command)
        {
            var result = await _facade.CreateRole(command);
            return CommandResult(result);
        }

        // PUT api/<RoleController>/5
        [HttpPut]
        public async Task<ApiResult> Put(UpdateRoleCommand command)
        {
            var result = await _facade.EditRole(command);
            return CommandResult(result); 
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ApiResult> Delete(long id)
        {
            var result = await _facade.DeleteRole(id);
            return CommandResult(result);
        }
        [AllowAnonymous]
        [HttpGet("GetByFilter")]
        public async Task<ApiResult<RoleFilterResult>> GetRolesByFilter([FromQuery] RoleFilterParam filterParams)
        {
            return QueryResult(await _facade.GetRolesByFilter(filterParams));
        }
    }

}
