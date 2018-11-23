namespace Cooperchip.MedicalManagement.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEntityTypeConfigurationWithFluentApi : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bairro", "CidadeId", "dbo.Cidade");
            DropForeignKey("dbo.Cidade", "UfId", "dbo.Uf");
            DropPrimaryKey("dbo.Bairro");
            DropPrimaryKey("dbo.Cidade");
            DropPrimaryKey("dbo.Uf");
            AddPrimaryKey("dbo.Bairro", "Id");
            AddPrimaryKey("dbo.Cidade", "Id");
            AddPrimaryKey("dbo.Uf", "Id");
            DropColumn("dbo.Bairro", "BairroId");
            DropColumn("dbo.Cidade", "CidadeId");
            DropColumn("dbo.Uf", "UfId");
            AddColumn("dbo.Bairro", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cidade", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Uf", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Bairro", "Descricao", c => c.String(nullable: false, maxLength: 70, unicode: false));
            AlterColumn("dbo.Cidade", "Descricao", c => c.String(nullable: false, maxLength: 70, unicode: false));
            AlterColumn("dbo.Uf", "Sigla", c => c.String(nullable: false, maxLength: 2, unicode: false));
            AlterColumn("dbo.Uf", "Estado", c => c.String(nullable: false, maxLength: 100, unicode: false));
            AddForeignKey("dbo.Bairro", "CidadeId", "dbo.Cidade", "Id");
            AddForeignKey("dbo.Cidade", "UfId", "dbo.Uf", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Cidade", "UfId", "dbo.Uf");
            DropForeignKey("dbo.Bairro", "CidadeId", "dbo.Cidade");
            DropPrimaryKey("dbo.Uf");
            DropPrimaryKey("dbo.Cidade");
            DropPrimaryKey("dbo.Bairro");
            DropColumn("dbo.Uf", "Id");
            DropColumn("dbo.Cidade", "Id");
            DropColumn("dbo.Bairro", "Id");
            AddColumn("dbo.Uf", "UfId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Cidade", "CidadeId", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Bairro", "BairroId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Uf", "Estado", c => c.String(maxLength: 80, unicode: false));
            AlterColumn("dbo.Uf", "Sigla", c => c.String(maxLength: 80, unicode: false));
            AlterColumn("dbo.Cidade", "Descricao", c => c.String(maxLength: 80, unicode: false));
            AlterColumn("dbo.Bairro", "Descricao", c => c.String(maxLength: 80, unicode: false));
            AddPrimaryKey("dbo.Uf", "UfId");
            AddPrimaryKey("dbo.Cidade", "CidadeId");
            AddPrimaryKey("dbo.Bairro", "BairroId");
            AddForeignKey("dbo.Cidade", "UfId", "dbo.Uf", "UfId");
            AddForeignKey("dbo.Bairro", "CidadeId", "dbo.Cidade", "CidadeId");
        }
    }
}
