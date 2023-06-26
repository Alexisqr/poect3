using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelterDAL.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KindOfAnimals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKind = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KindOfAn__3214EC275922B149", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "KindOfGoods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NameKind = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__KindOfGo__3214EC27BA14D8B1", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Volonters",
                columns: table => new
                {
                    IDVolonters = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    LastName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    PhoneNamber = table.Column<string>(type: "varchar(13)", unicode: false, maxLength: 13, nullable: true),
                    EMail = table.Column<string>(name: "E-Mail", type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Role = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Volonter__D3BC0C3D529BEE2B", x => x.IDVolonters);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    IDAnimal = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Kind = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Animals__5D8F073D76DB50EF", x => x.IDAnimal);
                    table.ForeignKey(
                        name: "FK__Animals__Kind__2A4B4B5E",
                        column: x => x.Kind,
                        principalTable: "KindOfAnimals",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Goods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    NameKind = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Goods__3214EC27E5FDF0B2", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Goods__NameKind__2D27B809",
                        column: x => x.NameKind,
                        principalTable: "KindOfGoods",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "ComentGlob",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ComentGl__3214EC270345D92A", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ComentGlo__IDVol__403A8C7D",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "IDVolonters");
                });

            migrationBuilder.CreateTable(
                name: "ComentKindAnimals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    IDKindAnimals = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ComentKi__3214EC27C48BBC0C", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ComentKin__IDKin__3D5E1FD2",
                        column: x => x.IDKindAnimals,
                        principalTable: "KindOfAnimals",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__ComentKin__IDVol__3C69FB99",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "IDVolonters");
                });

            migrationBuilder.CreateTable(
                name: "Volonters_Animals",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    IDAnimals = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Volonter__3214EC274D2062F6", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Volonters__IDAni__31EC6D26",
                        column: x => x.IDAnimals,
                        principalTable: "Animals",
                        principalColumn: "IDAnimal");
                    table.ForeignKey(
                        name: "FK__Volonters__IDVol__30F848ED",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "IDVolonters");
                });

            migrationBuilder.CreateTable(
                name: "ComentGood",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    IDGood = table.Column<int>(type: "int", nullable: false),
                    Text = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: true),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ComentGo__3214EC273E438E7E", x => x.ID);
                    table.ForeignKey(
                        name: "FK__ComentGoo__IDGoo__398D8EEE",
                        column: x => x.IDGood,
                        principalTable: "Goods",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__ComentGoo__IDVol__38996AB5",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "IDVolonters");
                });

            migrationBuilder.CreateTable(
                name: "Volonters_Goods",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IDVolonter = table.Column<int>(type: "int", nullable: false),
                    IDGood = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Volonter__3214EC27F53949D1", x => x.ID);
                    table.ForeignKey(
                        name: "FK__Volonters__IDGoo__35BCFE0A",
                        column: x => x.IDGood,
                        principalTable: "Goods",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__Volonters__IDVol__34C8D9D1",
                        column: x => x.IDVolonter,
                        principalTable: "Volonters",
                        principalColumn: "IDVolonters");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_Kind",
                table: "Animals",
                column: "Kind");

            migrationBuilder.CreateIndex(
                name: "IX_ComentGlob_IDVolonter",
                table: "ComentGlob",
                column: "IDVolonter");

            migrationBuilder.CreateIndex(
                name: "IX_ComentGood_IDGood",
                table: "ComentGood",
                column: "IDGood");

            migrationBuilder.CreateIndex(
                name: "IX_ComentGood_IDVolonter",
                table: "ComentGood",
                column: "IDVolonter");

            migrationBuilder.CreateIndex(
                name: "IX_ComentKindAnimals_IDKindAnimals",
                table: "ComentKindAnimals",
                column: "IDKindAnimals");

            migrationBuilder.CreateIndex(
                name: "IX_ComentKindAnimals_IDVolonter",
                table: "ComentKindAnimals",
                column: "IDVolonter");

            migrationBuilder.CreateIndex(
                name: "IX_Goods_NameKind",
                table: "Goods",
                column: "NameKind");

            migrationBuilder.CreateIndex(
                name: "IX_Volonters_Animals_IDVolonter",
                table: "Volonters_Animals",
                column: "IDVolonter");

            migrationBuilder.CreateIndex(
                name: "UQ__Volonter__1CF18EFE0ECBD9ED",
                table: "Volonters_Animals",
                column: "IDAnimals",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Volonters_Goods_IDGood",
                table: "Volonters_Goods",
                column: "IDGood");

            migrationBuilder.CreateIndex(
                name: "IX_Volonters_Goods_IDVolonter",
                table: "Volonters_Goods",
                column: "IDVolonter");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentGlob");

            migrationBuilder.DropTable(
                name: "ComentGood");

            migrationBuilder.DropTable(
                name: "ComentKindAnimals");

            migrationBuilder.DropTable(
                name: "Volonters_Animals");

            migrationBuilder.DropTable(
                name: "Volonters_Goods");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Goods");

            migrationBuilder.DropTable(
                name: "Volonters");

            migrationBuilder.DropTable(
                name: "KindOfAnimals");

            migrationBuilder.DropTable(
                name: "KindOfGoods");
        }
    }
}
