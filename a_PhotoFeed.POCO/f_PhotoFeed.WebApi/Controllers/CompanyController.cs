using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using e_PhotoFeed.Services.Interfaces;

namespace f_PhotoFeed.WebApi.Controllers
{
    [RoutePrefix("api/company")]
    public class CompanyController : BaseApiController
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        [HttpGet]
        [Route("getPendingCompanies")]
        public IHttpActionResult GetPendingCompanies()
        {
            var result = _companyService.GetPendingCompanies();
            return Ok(result);
        }

        [HttpPut]
        [Route("denyComapny/{companyId}")]
        public IHttpActionResult DenyCompany(int companyId)
        {
            _companyService.DenyCompany(companyId);
            return Ok();
        }

        [HttpPut]
        [Route("allowComapny/{companyId}")]
        public IHttpActionResult AllowCompany(int companyId)
        {
            _companyService.AllowCompany(companyId);
            return Ok();
        }

        [HttpGet]
        [Route("get/{companyId}")]
        public IHttpActionResult Get(int companyId)
        {
            var result = _companyService.GetCompanyProfile(companyId);
            return Ok(result);
        }

        [HttpGet]
        [Route("get/members/{companyId}")]
        public IHttpActionResult GetMembers(int companyId)
        {
            var result = _companyService.GetCompanyMembers(companyId);
            return Ok(result);
        }


    }
}
