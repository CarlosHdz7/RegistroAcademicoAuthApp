using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroAcademicoApp.Server.Migrations
{
    public partial class academico : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facultad",
                columns: table => new
                {
                    FacultadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facultad", x => x.FacultadId);
                });

            migrationBuilder.CreateTable(
                name: "Grado",
                columns: table => new
                {
                    GradoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GradoNombre = table.Column<string>(nullable: true),
                    Seccion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grado", x => x.GradoId);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    MaestroId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.MaestroId);
                });

            migrationBuilder.CreateTable(
                name: "Seccion",
                columns: table => new
                {
                    IdSeccion = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccion", x => x.IdSeccion);
                });

            migrationBuilder.CreateTable(
                name: "CuposCurso",
                columns: table => new
                {
                    IdCuposCurso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cupo = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    CursosId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuposCurso", x => x.IdCuposCurso);
                });

            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    DoB = table.Column<DateTime>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    Altura = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Peso = table.Column<float>(nullable: false),
                    FacultadRefId = table.Column<int>(nullable: false),
                    NumeroRegistro = table.Column<int>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: true),
                    GradoId = table.Column<int>(nullable: false),
                    CursosCursoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdEstudiante);
                    table.ForeignKey(
                        name: "FK_Estudiante_Facultad_FacultadRefId",
                        column: x => x.FacultadRefId,
                        principalTable: "Facultad",
                        principalColumn: "FacultadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estudiante_Grado_GradoId",
                        column: x => x.GradoId,
                        principalTable: "Grado",
                        principalColumn: "GradoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DireccionEstudiantes",
                columns: table => new
                {
                    IdDireccionEstudiante = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Direccion1 = table.Column<string>(nullable: true),
                    Direccion2 = table.Column<string>(nullable: true),
                    EstudianteIdEstudiante = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DireccionEstudiantes", x => x.IdDireccionEstudiante);
                    table.ForeignKey(
                        name: "FK_DireccionEstudiantes_Estudiante_EstudianteIdEstudiante",
                        column: x => x.EstudianteIdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EncRegistroAcademcico",
                columns: table => new
                {
                    IdEncRegistroAcad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(nullable: false),
                    EstudianteId = table.Column<int>(nullable: true),
                    DetRegId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncRegistroAcademcico", x => x.IdEncRegistroAcad);
                    table.ForeignKey(
                        name: "FK_EncRegistroAcademcico_Estudiante_EstudianteId",
                        column: x => x.EstudianteId,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetRegistroAcademico",
                columns: table => new
                {
                    DetRegistroIdAcad = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CursosId = table.Column<int>(nullable: true),
                    EncRegistroAcademicoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetRegistroAcademico", x => x.DetRegistroIdAcad);
                    table.ForeignKey(
                        name: "FK_DetRegistroAcademico_EncRegistroAcademcico_EncRegistroAcademicoId",
                        column: x => x.EncRegistroAcademicoId,
                        principalTable: "EncRegistroAcademcico",
                        principalColumn: "IdEncRegistroAcad",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    CursoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCurso = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    onLineMaestrosId = table.Column<int>(nullable: true),
                    presencialMaestrosID = table.Column<int>(nullable: true),
                    CurposCursoId = table.Column<int>(nullable: true),
                    DetRegistroAcademicoDetRegistroIdAcad = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.CursoId);
                    table.ForeignKey(
                        name: "FK_Cursos_DetRegistroAcademico_DetRegistroAcademicoDetRegistroIdAcad",
                        column: x => x.DetRegistroAcademicoDetRegistroIdAcad,
                        principalTable: "DetRegistroAcademico",
                        principalColumn: "DetRegistroIdAcad",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursos_Maestros_onLineMaestrosId",
                        column: x => x.onLineMaestrosId,
                        principalTable: "Maestros",
                        principalColumn: "MaestroId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cursos_Maestros_presencialMaestrosID",
                        column: x => x.presencialMaestrosID,
                        principalTable: "Maestros",
                        principalColumn: "MaestroId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuposCurso_CursosId",
                table: "CuposCurso",
                column: "CursosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_DetRegistroAcademicoDetRegistroIdAcad",
                table: "Cursos",
                column: "DetRegistroAcademicoDetRegistroIdAcad");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_onLineMaestrosId",
                table: "Cursos",
                column: "onLineMaestrosId");

            migrationBuilder.CreateIndex(
                name: "IX_Cursos_presencialMaestrosID",
                table: "Cursos",
                column: "presencialMaestrosID");

            migrationBuilder.CreateIndex(
                name: "IX_DetRegistroAcademico_EncRegistroAcademicoId",
                table: "DetRegistroAcademico",
                column: "EncRegistroAcademicoId");

            migrationBuilder.CreateIndex(
                name: "IX_DireccionEstudiantes_EstudianteIdEstudiante",
                table: "DireccionEstudiantes",
                column: "EstudianteIdEstudiante");

            migrationBuilder.CreateIndex(
                name: "IX_EncRegistroAcademcico_EstudianteId",
                table: "EncRegistroAcademcico",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_CursosCursoId",
                table: "Estudiante",
                column: "CursosCursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_FacultadRefId",
                table: "Estudiante",
                column: "FacultadRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_GradoId",
                table: "Estudiante",
                column: "GradoId");

            migrationBuilder.AddForeignKey(
                name: "FK_CuposCurso_Cursos_CursosId",
                table: "CuposCurso",
                column: "CursosId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Cursos_CursosCursoId",
                table: "Estudiante",
                column: "CursosCursoId",
                principalTable: "Cursos",
                principalColumn: "CursoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Cursos_CursosCursoId",
                table: "Estudiante");

            migrationBuilder.DropTable(
                name: "CuposCurso");

            migrationBuilder.DropTable(
                name: "DireccionEstudiantes");

            migrationBuilder.DropTable(
                name: "Seccion");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "DetRegistroAcademico");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "EncRegistroAcademcico");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Facultad");

            migrationBuilder.DropTable(
                name: "Grado");
        }
    }
}
