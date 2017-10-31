namespace Generic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajout_Identity_Nom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Nom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Nom");
        }
    }
}
