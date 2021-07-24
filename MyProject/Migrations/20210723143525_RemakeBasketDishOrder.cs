using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProject.Migrations
{
    public partial class RemakeBasketDishOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDish");

            migrationBuilder.DropTable(
                name: "DishOrder");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Orders",
                newName: "TotalPrice");

            migrationBuilder.RenameColumn(
                name: "OrderName",
                table: "Orders",
                newName: "OrderNumber");

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Delivery",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PaymentMethod",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "DishesInOrderd",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Size = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<int>(type: "int", nullable: false),
                    Measure = table.Column<int>(type: "int", nullable: false),
                    Prise = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishesInOrderd", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BasketDishInOrder",
                columns: table => new
                {
                    BasketsId = table.Column<long>(type: "bigint", nullable: false),
                    DishesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDishInOrder", x => new { x.BasketsId, x.DishesId });
                    table.ForeignKey(
                        name: "FK_BasketDishInOrder_Baskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketDishInOrder_DishesInOrderd_DishesId",
                        column: x => x.DishesId,
                        principalTable: "DishesInOrderd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishInOrderOrder",
                columns: table => new
                {
                    DishesInOrderId = table.Column<long>(type: "bigint", nullable: false),
                    OrdersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishInOrderOrder", x => new { x.DishesInOrderId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DishInOrderOrder_DishesInOrderd_DishesInOrderId",
                        column: x => x.DishesInOrderId,
                        principalTable: "DishesInOrderd",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishInOrderOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketDishInOrder_DishesId",
                table: "BasketDishInOrder",
                column: "DishesId");

            migrationBuilder.CreateIndex(
                name: "IX_DishInOrderOrder_OrdersId",
                table: "DishInOrderOrder",
                column: "OrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketDishInOrder");

            migrationBuilder.DropTable(
                name: "DishInOrderOrder");

            migrationBuilder.DropTable(
                name: "DishesInOrderd");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Delivery",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "TotalPrice",
                table: "Orders",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "OrderNumber",
                table: "Orders",
                newName: "OrderName");

            migrationBuilder.CreateTable(
                name: "BasketDish",
                columns: table => new
                {
                    BasketsId = table.Column<long>(type: "bigint", nullable: false),
                    DishesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketDish", x => new { x.BasketsId, x.DishesId });
                    table.ForeignKey(
                        name: "FK_BasketDish_Baskets_BasketsId",
                        column: x => x.BasketsId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketDish_Dishes_DishesId",
                        column: x => x.DishesId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DishOrder",
                columns: table => new
                {
                    DishesInOrderId = table.Column<long>(type: "bigint", nullable: false),
                    OrdersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DishOrder", x => new { x.DishesInOrderId, x.OrdersId });
                    table.ForeignKey(
                        name: "FK_DishOrder_Dishes_DishesInOrderId",
                        column: x => x.DishesInOrderId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DishOrder_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketDish_DishesId",
                table: "BasketDish",
                column: "DishesId");

            migrationBuilder.CreateIndex(
                name: "IX_DishOrder_OrdersId",
                table: "DishOrder",
                column: "OrdersId");
        }
    }
}
