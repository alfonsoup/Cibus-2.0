namespace CibusMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CibusEntities : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carts",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        CartId = c.String(),
                        IdComboRestaurante = c.Int(nullable: false),
                        Cantidad = c.Int(nullable: false),
                        FechaCreacion = c.DateTime(),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.ComboRestaurantes", t => t.IdComboRestaurante, cascadeDelete: true)
                .Index(t => t.IdComboRestaurante);
            
            CreateTable(
                "dbo.ComboRestaurantes",
                c => new
                    {
                        IdComboRestaurante = c.Int(nullable: false, identity: true),
                        IdRestaurante = c.Int(nullable: false),
                        Nombre = c.String(),
                        Descripcion = c.String(),
                        Precio = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Imagen = c.String(),
                    })
                .PrimaryKey(t => t.IdComboRestaurante)
                .ForeignKey("dbo.Restaurantes", t => t.IdRestaurante, cascadeDelete: true)
                .Index(t => t.IdRestaurante);
            
            CreateTable(
                "dbo.DetallePedidoes",
                c => new
                    {
                        IdDetallePedido = c.Int(nullable: false, identity: true),
                        IdComboRestaurante = c.Int(nullable: false),
                        IdPedido = c.Int(nullable: false),
                        Cantidad = c.Int(),
                        PrecioUnitario = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdDetallePedido)
                .ForeignKey("dbo.ComboRestaurantes", t => t.IdComboRestaurante, cascadeDelete: true)
                .ForeignKey("dbo.Pedidoes", t => t.IdPedido, cascadeDelete: true)
                .Index(t => t.IdComboRestaurante)
                .Index(t => t.IdPedido);
            
            CreateTable(
                "dbo.Pedidoes",
                c => new
                    {
                        IdPedido = c.Int(nullable: false, identity: true),
                        IdCliente = c.String(),
                        Fecha = c.DateTime(),
                        Total = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.IdPedido);
            
            CreateTable(
                "dbo.Restaurantes",
                c => new
                    {
                        IdRestaurante = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Telefono = c.String(),
                        Logo = c.String(),
                        Tipo = c.String(),
                    })
                .PrimaryKey(t => t.IdRestaurante);
            
            CreateIndex("dbo.AspNetUsers", "IdRestaurante");
            AddForeignKey("dbo.AspNetUsers", "IdRestaurante", "dbo.Restaurantes", "IdRestaurante", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "IdRestaurante", "dbo.Restaurantes");
            DropForeignKey("dbo.ComboRestaurantes", "IdRestaurante", "dbo.Restaurantes");
            DropForeignKey("dbo.DetallePedidoes", "IdPedido", "dbo.Pedidoes");
            DropForeignKey("dbo.DetallePedidoes", "IdComboRestaurante", "dbo.ComboRestaurantes");
            DropForeignKey("dbo.Carts", "IdComboRestaurante", "dbo.ComboRestaurantes");
            DropIndex("dbo.AspNetUsers", new[] { "IdRestaurante" });
            DropIndex("dbo.DetallePedidoes", new[] { "IdPedido" });
            DropIndex("dbo.DetallePedidoes", new[] { "IdComboRestaurante" });
            DropIndex("dbo.ComboRestaurantes", new[] { "IdRestaurante" });
            DropIndex("dbo.Carts", new[] { "IdComboRestaurante" });
            DropTable("dbo.Restaurantes");
            DropTable("dbo.Pedidoes");
            DropTable("dbo.DetallePedidoes");
            DropTable("dbo.ComboRestaurantes");
            DropTable("dbo.Carts");
        }
    }
}
