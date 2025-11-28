using App.Domain.AppService.AuthorAgg;
using App.Domain.AppService.CategoryAgg;
using App.Domain.AppService.CommentAgg;
using App.Domain.AppService.PostAgg;
using App.Domain.Core.AuthorAgg.Contracts;
using App.Domain.Core.CategoryAgg.Contracts;
using App.Domain.Core.CommentAgg.Contracts;
using App.Domain.Core.PostAgg.Contracts;
using App.Domain.Service.AuthorAgg;
using App.Domain.Service.CategoryAgg;
using App.Domain.Service.CommentAgg;
using App.Domain.Service.PostAgg;
using App.Infrastructure.EfCore.Persistence;
using App.Infrastructure.EfCore.Repositories.AuthorAgg;
using App.Infrastructure.EfCore.Repositories.CategoryAgg;
using App.Infrastructure.EfCore.Repositories.CommentAgg;
using App.Infrastructure.EfCore.Repositories.PostAgg;
using App.Infrastructure.FileService.Contracts;
using App.Infrastructure.FileService.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(@"Server=DESKTOP-I05OKD5\SQLEXPRESS;Database=SharpBlog;Integrated Security=true;TrustServerCertificate=true;"));

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IAuthorAppService, AuthorAppService>();

builder.Services.AddScoped<IPostRepository, PostRepository>();
builder.Services.AddScoped<IPostService, PostService>();
builder.Services.AddScoped<IPostAppService, PostAppService>();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryAppService, CategoryAppService>();

builder.Services.AddScoped<IFileService, FileService>();

builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<ICommentAppService, CommentAppService>();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
