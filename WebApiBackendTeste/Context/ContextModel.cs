using System.Data.Entity;
using WebApiBackendTeste.Model;

namespace WebApiBackendTeste.Context
{
    public class ContextModel : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ContextModel() : base("name=ContextModel")
        {
            
        }     

        /// <summary>
        /// 
        /// </summary>
        public DbSet<Estado> Estados { get; set; }           
    }
}
