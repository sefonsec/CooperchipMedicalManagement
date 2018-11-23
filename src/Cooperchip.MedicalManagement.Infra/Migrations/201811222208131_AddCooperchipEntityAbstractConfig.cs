namespace Cooperchip.MedicalManagement.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCooperchipEntityAbstractConfig : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Bairro", newName: "TLB_Bairro");
            RenameTable(name: "dbo.Cidade", newName: "TBL_Cidade");
            RenameTable(name: "dbo.Uf", newName: "TBL_Uf");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.TBL_Uf", newName: "Uf");
            RenameTable(name: "dbo.TBL_Cidade", newName: "Cidade");
            RenameTable(name: "dbo.TLB_Bairro", newName: "Bairro");
        }
    }
}
