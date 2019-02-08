namespace WebTransportCompany.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Specialty = c.String(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recalls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        Comment = c.String(),
                        Doctor_Id = c.Int(nullable: false),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Doctors", t => t.Doctor_Id, cascadeDelete: true)
                .Index(t => t.Doctor_Id);
            
            CreateTable(
                "dbo.Procedures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PriceOfProc = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recalls", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Recalls", new[] { "Doctor_Id" });
            DropTable("dbo.Procedures");
            DropTable("dbo.Recalls");
            DropTable("dbo.Doctors");
            DropTable("dbo.Clients");
        }
    }
}
