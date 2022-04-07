﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiHW.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CrudController : ControllerBase
{
    private readonly ValuesHolder _holder;
    public CrudController(ValuesHolder holder)
    {
        _holder = holder;
    }

    #region Create

    [HttpPost("create/{str}")]
    public IActionResult Create([FromRoute] string str)
    {
        _holder.Add(str);
        return Ok();
    }

    #endregion

    #region Read

    [HttpGet("read/{num}")]
    public IActionResult Read([FromRoute] int num)
    {
        string temp = _holder.Get(num)!;
        if (temp is not null)
            return Ok(temp);
        else
            return NotFound();
    }

    #endregion

    #region Update

    [HttpPut("update/{num}/{str}")]
    public IActionResult Update([FromRoute] string str, [FromRoute] int num)
    {
        if (_holder.Update(num, str))
            return Ok("updated");
        else
            return NotFound();
    }

    #endregion

    #region Delete

    [HttpDelete("delete/{num}")]
    public IActionResult Delete([FromRoute] int num)
    {
        if (_holder.Delete(num))
            return Ok("Deleted");
        else
            return NotFound();
    }

    #endregion
}
