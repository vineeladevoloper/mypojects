using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using taskmanagement2.DTOS;
using taskmanagement2.Irepos;

[ApiController]
[Route("api/comments")]
public class CommentController : ControllerBase
{
    private readonly ICommentService _commentService;

    public CommentController(ICommentService commentService)
    {
        _commentService = commentService;
    }

    [HttpPost("add")]
    public IActionResult AddComment([FromBody] CommentDTO commentDto)
    {
        try
        {
            _commentService.AddComment(commentDto);
            return Ok("Comment added successfully");
        }
        catch (Exception ex)
        {
            // Log the exception
            return BadRequest($"Failed to add comment: {ex.Message}");
        }
    }

    [HttpGet("getall/{postId}")]
    public IActionResult GetAllCommentsForPost(int postId, MyDbContext myDbContext)
    {
        try
        {
            List<CommentDTO> comments = _commentService.GetAllCommentsForPost(postId, myDbContext);
            return Ok(comments);
        }
        catch (Exception ex)
        {
            // Log the exception
            return BadRequest($"Failed to retrieve comments: {ex.Message}");
        }
    }
}
