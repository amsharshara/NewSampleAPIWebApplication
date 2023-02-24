using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Xml.Linq;
using WebApplication16.DB;

namespace WebApplication16
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder=WebApplication.CreateBuilder(args);
            builder.Services.AddScoped<ICarsRespoitory, CarRespoitory>();
            
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            //
            var app=builder.Build();
            if(app.Environment.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                
            }
           
            app.MapControllers();
            app.Run();

        
            
        }
        //public static  void Main(string[] args)
        //{

        //    var builder = WebApplication.CreateBuilder(args);
        //    builder.Services.AddControllers();
        //    //
        //    var app = builder.Build();


        //    ////
        //    //app.MapGet("/", () => "test").RequireAuthorization();
        //    //app.MapGet("/ToDo", async (IDB db) => db.GetAll());
        //    //app.MapGet("/ToDo/{id}", async (int id,IDB db) =>(await db.Find(id)) );
        //    //app.MapPost("/ToDo", (test t, IDB db) => db.Add(t));
        //    //app.MapPut("/ToDo/{id}", (int id,test t, IDB db) => db.Edit(t));
        //    //app.MapDelete("/ToDo/{id}", (int id, IDB db)=>db.Delete(id));

        //    //app.MapGet("/", async (IDB db) => await db.GetAll());
        //    //app.MapPut("/edit", async (int i,string name,IDB db) =>
        //    //{
        //    //    var it=await db.Edit(new test() { id=i,name=name});

        //    //    Results.Ok();
        //    //});
        //    //app.MapDelete("/delete", async (int id,IDB db) =>{
        //    //   var it= await db.Delete(id);
        //    //    Results.Ok();
        //    //});
        //    //app.MapPost("/post", async (int i, string name, IDB db) =>
        //    //{
        //    //    await db.Add(new test() { id = i, name = name });
        //    //    Results.Ok();
        //    //});
        //    app.UseRouting();
        //    app.UseHttpsRedirection();

        //    app.MapControllers();
        //    app.Run();
        //    //// Add services to the container.
        //    //builder.Services.AddRazorPages();

        //    //var app = builder.Build();

        //    //// Configure the HTTP request pipeline.
        //    //if (!app.Environment.IsDevelopment())
        //    //{
        //    //    app.UseExceptionHandler("/Error");
        //    //    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        //    //    app.UseHsts();
        //    //}

        //    //app.UseHttpsRedirection();
        //    //app.UseStaticFiles();

        //    //app.UseRouting();

        //    //app.UseAuthorization();

        //    //app.MapRazorPages();

        //    //app.Run();
        //}
    }
   
}