﻿using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Repositories;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("[controller]")]
    public class MovieApiController : Controller
    {
        private readonly IMovieService _movieService;
        public MovieApiController(IMovieService movieService)
        {
            this._movieService = movieService;
        }
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _movieService.GetAll();
                return Ok(new { isSuccess = true, data = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    statusCode = 500,
                    message = ex.Message
                });
            }
        }
        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await _movieService.GetById(id);
                return Ok(new { isSuccess = true, data = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    statusCode = 500,
                    message = ex.Message
                });


            }
        }
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromForm] Movie model)
        {
            try
            {
                var result = await _movieService.Add(model);
                return Ok(new { isSuccess = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    statusCode = 500,
                    message = ex.Message
                });


            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var result = await _movieService.Delete(id);
                return Ok(new { isSuccess = result });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    statusCode = 500,
                    message = ex.Message
                });


            }
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update([FromForm] Movie model)
        {
            try
            {
                var result = await _movieService.Update(model);
                return Ok(new { isSuccess = true });
            }
            catch (Exception ex)
            {
                return new JsonResult(new
                {
                    isSuccess = false,
                    statusCode = 500,
                    message = ex.Message
                });
            }
        }



    }

}
