namespace Generic.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Ajout_Identity_Prenom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Prenom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Prenom");
        }
    }
}
