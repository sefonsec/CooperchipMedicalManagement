namespace Cooperchip.MedicalManagement.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bairro",
                c => new
                    {
                        BairroId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 80, unicode: false),
                        CidadeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BairroId)
                .ForeignKey("dbo.Cidade", t => t.CidadeId)
                .Index(t => t.CidadeId);
            
            CreateTable(
                "dbo.Cidade",
                c => new
                    {
                        CidadeId = c.Int(nullable: false, identity: true),
                        Descricao = c.String(maxLength: 80, unicode: false),
                        UfId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CidadeId)
                .ForeignKey("dbo.Uf", t => t.UfId)
                .Index(t => t.UfId);
            
            CreateTable(
                "dbo.Uf",
                c => new
                    {
                        UfId = c.Int(nullable: false, identity: true),
                        Sigla = c.String(maxLength: 80, unicode: false),
                        Estado = c.String(maxLength: 80, unicode: false),
                        CodigoEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UfId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cidade", "UfId", "dbo.Uf");
            DropForeignKey("dbo.Bairro", "CidadeId", "dbo.Cidade");
            DropIndex("dbo.Cidade", new[] { "UfId" });
            DropIndex("dbo.Bairro", new[] { "CidadeId" });
            DropTable("dbo.Uf");
            DropTable("dbo.Cidade");
            DropTable("dbo.Bairro");
        }
    }
}
