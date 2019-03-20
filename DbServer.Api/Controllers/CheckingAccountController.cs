using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbServer.Api.DTO;
using DbServer.Domain.Entities;
using DbServer.Domain.Interfaces;
using DbServer.Service.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using DbServer.Api.Extentions;

namespace DbServer.Api.Controllers
{
    /// <summary>
    /// Post stest
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class CheckingAccountController : Controller
    {
        private readonly ICheckingAccountService _checkingAccountService;
        private readonly ICheckingAccountRepository _checkingAccountRepository;
        private readonly IMapper _mapper;

        /// <summary>
        /// Constructor
        /// </summary>
        public CheckingAccountController(ICheckingAccountRepository checkingAccountRepository, ICheckingAccountService checkingAccountService, IMapper mapper)
        {
            _checkingAccountRepository = checkingAccountRepository;
            _checkingAccountService = checkingAccountService;
            _mapper = mapper;
        }

        /// <summary>
        /// Create a new Checking Account
        /// </summary>
        /// <param name="item">Checking Account data</param> 
        [HttpPost("CreateAccount")]
        public IActionResult Post([FromBody] CheckingAccountDTO item)
        {
            try
            {
                var obj = this._checkingAccountService.Insert(item.Mapp<CheckingAccountDTO, CheckingAccount>(this._mapper));
                return new ObjectResult(obj.Mapp<CheckingAccount, CheckingAccountDTO>(this._mapper));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Return the Account Balance
        /// </summary>
        /// <param name="number">Checking Account Number eg: "000123"</param> 
        [HttpGet("GetBalance/{number}")]
        public IActionResult Get(string number)
        {
            try
            {
                return new ObjectResult(this._checkingAccountService.SelectByNumber(number));
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}