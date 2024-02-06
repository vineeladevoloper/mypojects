using Microsoft.EntityFrameworkCore;
using taskmanagement2;
using taskmanagement2.DTOS;
using taskmanagement2.Entities;
using taskmanagement2.Irepos;
using taskmanagement2.services;

public class MyDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Like> Likes { get; set; }
    public DbSet<CommentNotificationEntity> CommentNotifications { get;  set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Replace "your_connection_string" with your actual connection string
        optionsBuilder.UseSqlServer("Your_Actual_Connection_String");
    }
}
