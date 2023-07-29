using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    public partial class Pass1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Combos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Combos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Loai = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Anh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiaBan = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    TrangThai = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "comboDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProductDetail = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdCombo = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    GiaBan = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comboDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_comboDetails_Combos_IdCombo",
                        column: x => x.IdCombo,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_comboDetails_ProductDetails_IdProductDetail",
                        column: x => x.IdProductDetail,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdRole = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Ma = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Ten = table.Column<string>(type: "nvarchar(300)", nullable: false),
                    DiaChi = table.Column<string>(type: "nvarchar(MAX)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    MatKhau = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bills",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdUser = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Ma = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    NgayTao = table.Column<DateTime>(type: "DateTime", nullable: true),
                    NgayThanhToan = table.Column<DateTime>(type: "DateTime", nullable: true),
                    DiaChi = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    Sdt = table.Column<string>(type: "nvarchar(1000)", nullable: true),
                    TienShip = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bills_Users_IdUser",
                        column: x => x.IdUser,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    UserID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_Carts_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BillDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdBill = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IdProductDetail = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    IdCombo = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: true),
                    SoLuong = table.Column<int>(type: "int", nullable: true),
                    DonGia = table.Column<decimal>(type: "decimal", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BillDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BillDetails_Bills_IdBill",
                        column: x => x.IdBill,
                        principalTable: "Bills",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillDetails_Combos_IdCombo",
                        column: x => x.IdCombo,
                        principalTable: "Combos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BillDetails_ProductDetails_IdProductDetail",
                        column: x => x.IdProductDetail,
                        principalTable: "ProductDetails",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CartDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    DetailProductID = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    IdCombo = table.Column<Guid>(type: "UNIQUEIDENTIFIER", nullable: false),
                    Soluong = table.Column<int>(type: "int", nullable: false),
                    Dongia = table.Column<decimal>(type: "decimal", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartDetails_Carts_UserID",
                        column: x => x.UserID,
                        principalTable: "Carts",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_Combos_IdCombo",
                        column: x => x.IdCombo,
                        principalTable: "Combos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartDetails_ProductDetails_DetailProductID",
                        column: x => x.DetailProductID,
                        principalTable: "ProductDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IdBill",
                table: "BillDetails",
                column: "IdBill");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IdCombo",
                table: "BillDetails",
                column: "IdCombo");

            migrationBuilder.CreateIndex(
                name: "IX_BillDetails_IdProductDetail",
                table: "BillDetails",
                column: "IdProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_Bills_IdUser",
                table: "Bills",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_DetailProductID",
                table: "CartDetails",
                column: "DetailProductID");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_IdCombo",
                table: "CartDetails",
                column: "IdCombo");

            migrationBuilder.CreateIndex(
                name: "IX_CartDetails_UserID",
                table: "CartDetails",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_comboDetails_IdCombo",
                table: "comboDetails",
                column: "IdCombo");

            migrationBuilder.CreateIndex(
                name: "IX_comboDetails_IdProductDetail",
                table: "comboDetails",
                column: "IdProductDetail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BillDetails");

            migrationBuilder.DropTable(
                name: "CartDetails");

            migrationBuilder.DropTable(
                name: "comboDetails");

            migrationBuilder.DropTable(
                name: "Bills");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropTable(
                name: "Combos");

            migrationBuilder.DropTable(
                name: "ProductDetails");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
