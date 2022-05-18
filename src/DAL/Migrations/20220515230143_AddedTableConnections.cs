using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class AddedTableConnections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hashtags_Posts_PostId",
                table: "Hashtags");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Posts_PostId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_PostId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Hashtags_PostId",
                table: "Hashtags");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Hashtags");

            migrationBuilder.CreateTable(
                name: "PostHashtag",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    HashtagId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostHashtag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostHashtag_Hashtags_HashtagId",
                        column: x => x.HashtagId,
                        principalTable: "Hashtags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostHashtag_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PostTopic",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    PostId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci"),
                    TopicId = table.Column<Guid>(type: "char(36)", nullable: false, collation: "ascii_general_ci")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTopic", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostTopic_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PostTopic_Topics_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_PostHashtag_HashtagId",
                table: "PostHashtag",
                column: "HashtagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostHashtag_PostId",
                table: "PostHashtag",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTopic_PostId",
                table: "PostTopic",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_PostTopic_TopicId",
                table: "PostTopic",
                column: "TopicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PostHashtag");

            migrationBuilder.DropTable(
                name: "PostTopic");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "Topics",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.AddColumn<Guid>(
                name: "PostId",
                table: "Hashtags",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci");

            migrationBuilder.CreateIndex(
                name: "IX_Topics_PostId",
                table: "Topics",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Hashtags_PostId",
                table: "Hashtags",
                column: "PostId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hashtags_Posts_PostId",
                table: "Hashtags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Posts_PostId",
                table: "Topics",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }
    }
}
