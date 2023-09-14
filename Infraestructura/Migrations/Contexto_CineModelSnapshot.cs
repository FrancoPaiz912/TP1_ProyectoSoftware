﻿using System;
using Infraestructura.EstructuraDB;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;


#nullable disable

namespace Infraestructura.Migrations
{
    [DbContext(typeof(Contexto_Cine))]
    partial class Contexto_CineModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Dominio.Funciones", b =>
                {
                    b.Property<int>("FuncionesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FuncionesId"));

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("PeliculaId")
                        .HasColumnType("int");

                    b.Property<int>("SalaId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("Tiempo")
                        .HasColumnType("time");

                    b.HasKey("FuncionesId");

                    b.HasIndex("PeliculaId");

                    b.HasIndex("SalaId");

                    b.ToTable("Funciones", (string)null);
                });

            modelBuilder.Entity("Dominio.Generos", b =>
                {
                    b.Property<int>("GenerosId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GenerosId"));

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("GenerosId");

                    b.ToTable("Genero", (string)null);

                    b.HasData(
                        new
                        {
                            GenerosId = 1,
                            Nombre = "Acción"
                        },
                        new
                        {
                            GenerosId = 2,
                            Nombre = "Aventuras"
                        },
                        new
                        {
                            GenerosId = 3,
                            Nombre = "Ciencia Ficción"
                        },
                        new
                        {
                            GenerosId = 4,
                            Nombre = "Comedia"
                        },
                        new
                        {
                            GenerosId = 5,
                            Nombre = "Documental"
                        },
                        new
                        {
                            GenerosId = 6,
                            Nombre = "Drama"
                        },
                        new
                        {
                            GenerosId = 7,
                            Nombre = "Fantasía"
                        },
                        new
                        {
                            GenerosId = 8,
                            Nombre = "Musical"
                        },
                        new
                        {
                            GenerosId = 9,
                            Nombre = "Suspenso"
                        },
                        new
                        {
                            GenerosId = 10,
                            Nombre = "Terror"
                        });
                });

            modelBuilder.Entity("Dominio.Peliculas", b =>
                {
                    b.Property<int>("Peliculasid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Peliculasid"));

                    b.Property<int>("Genero")
                        .HasColumnType("int");

                    b.Property<string>("Poster")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Sinopsis")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Peliculasid");

                    b.HasIndex("Genero");

                    b.ToTable("Peliculas", (string)null);

                    b.HasData(
                        new
                        {
                            Peliculasid = 1,
                            Genero = 2,
                            Poster = "https://sm.ign.com/t/ign_es/screenshot/default/d0n-cinv4aahikr_mmkj.960.jpg",
                            Sinopsis = "Tras el asesinato de su padre, Simba, un joven león es apartado su reino y tendrá que descubrir con ayuda de amigos de la sabana africana el significado de la responsabilidad y la valentía. Más tarde volverá para recuperar el control de su reino.",
                            Titulo = "EL REY LEÓN",
                            Trailer = "https://www.youtube.com/watch?v=0U-kFH-ixV0&ab_channel=DubZone%3ALatinoam%C3%A9rica"
                        },
                        new
                        {
                            Peliculasid = 2,
                            Genero = 7,
                            Poster = "https://i.blogs.es/617177/super-mario-bros-pelicula-mario/450_1000.webpupdate-database",
                            Sinopsis = "Dos hermanos plomeros, Mario y Luigi, caen por las alcantarillas y llegan a un mundo subterráneo mágico en el que deben enfrentarse al malvado Bowser para rescatar a la princesa Peach, quien ha sido forzada a aceptar casarse con él.",
                            Titulo = "MARIO BROS",
                            Trailer = "https://www.youtube.com/watch?v=SvJwEiy2Wok&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 3,
                            Genero = 7,
                            Poster = "https://es.web.img3.acsta.net/pictures/22/06/16/12/54/0504030.jpg",
                            Sinopsis = "Gato ha usado ocho de sus nueve vidas y ha perdido la cuenta. Para recuperarlas, se embarca en una gran aventura en la Selva Negra en busca de la mítica Estrella del Deseo, su última esperanza de recuperar sus vidas perdidas.",
                            Titulo = "EL GATO CON BOTAS: EL ÚLTIMO DESEO",
                            Trailer = "https://www.youtube.com/watch?v=O_pRSxYuSU8&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 4,
                            Genero = 3,
                            Poster = "https://hips.hearstapps.com/hmg-prod/images/poster-vengadores-endgame-1552567490.jpg",
                            Sinopsis = "Después de los devastadores eventos ocurridos en Vengadores: Infinity War, el universo está en ruinas debido a las acciones de Thanos, el Titán Loco. Tras la derrota, las cosas no pintan bien para los Vengadores.",
                            Titulo = "AVENGERS ENDGAME",
                            Trailer = "https://www.youtube.com/watch?v=Oy_SER6dfK4&ab_channel=Bel%C3%A9nOrtizM."
                        },
                        new
                        {
                            Peliculasid = 5,
                            Genero = 1,
                            Poster = "https://cdn.diariojornada.com.ar/imagenes/2023/5/22/347430_1_125855_raw.jpg",
                            Sinopsis = "Dom Toretto y sus familias se enfrentan al peor enemigo imaginable, uno llegado desde el pasado con sed de venganza, dispuesto a cualquier cosa con tal de destruir todo aquello que Dom ama.",
                            Titulo = "RAPIDOS Y FURIOSOS 10",
                            Trailer = "https://www.youtube.com/watch?v=O5BOxn8Go8U&ab_channel=UniversalPicturesM%C3%A9xico"
                        },
                        new
                        {
                            Peliculasid = 6,
                            Genero = 2,
                            Poster = "https://image.tmdb.org/t/p/original/pgDWrhaz0rSsD43ocNDX3PRIKJ3.jpg",
                            Sinopsis = "Después de reunirse con Gwen Stacy, el amigable vecino de tiempo completo de Brooklyn Spiderman, es lanzado a través del multiverso, donde se encuentra a un equipo de gente araña encomendada con proteger su mera existencia.",
                            Titulo = "SPIDERMAN: A TRAVÉS DEL SPIDER-VERSO",
                            Trailer = "https://www.youtube.com/watch?v=rVLFOx7AQp0&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 7,
                            Genero = 4,
                            Poster = "https://fotos.perfil.com//2023/05/31/900/0/blondi-1579634.jpeg",
                            Sinopsis = "Blondi es una película que sigue la vida cotidiana de una joven madre y su hijo de veinte años, quienes viven como amigos compartiendo gustos por la música, las salidas nocturnas, la marihuana y el alcohol.",
                            Titulo = "BLONDI",
                            Trailer = "https://www.youtube.com/watch?v=4TQcc7W45oA&ab_channel=TulipPictures"
                        },
                        new
                        {
                            Peliculasid = 8,
                            Genero = 10,
                            Poster = "https://lavereda.com.ar/wp-content/uploads/2023/07/unnamed-1-691x1024.jpg",
                            Sinopsis = "Un mal se extiende en la Francia de 1956 cuando un sacerdote es asesinado y la hermana Irene se enfrenta de nuevo a la monja demoníaca Valak.",
                            Titulo = "LA MONJA 2",
                            Trailer = "https://www.youtube.com/watch?v=pdrPvHulyUY&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 9,
                            Genero = 9,
                            Poster = "https://pics.filmaffinity.com/Los_delincuentes-192145404-large.jpg",
                            Sinopsis = "Dos empleados de banco en un determinado momento de sus vidas se cuestionan la existencia rutinaria que llevan adelante. Uno de ellos encuentra una solución, cometer un delito. De alguna manera lo logra y compromete su destino al de su compañero.",
                            Titulo = "LOS DELINCUENTES",
                            Trailer = "https://www.youtube.com/watch?v=sxxbOFfagKI&ab_channel=WankaCine"
                        },
                        new
                        {
                            Peliculasid = 10,
                            Genero = 9,
                            Poster = "https://elcritico.com.ar/wp-content/uploads/2021/09/no-respires-dos-poster.jpg",
                            Sinopsis = "Un veterano ciego debe usar su entrenamiento militar para salvar a un joven huérfano de un grupo de matones que irrumpen en su casa.",
                            Titulo = "NO RESPIRES 2",
                            Trailer = "https://www.youtube.com/watch?v=RjPblH5m_PY&ab_channel=SonyPicturesM%C3%A9xico"
                        },
                        new
                        {
                            Peliculasid = 11,
                            Genero = 4,
                            Poster = "https://i.ebayimg.com/images/g/~yMAAOSw9d5kwP9m/s-l1200.webp",
                            Sinopsis = "Después de ser expulsada de Barbieland por no ser una muñeca de aspecto perfecto, Barbie parte hacia el mundo humano para encontrar la verdadera felicidad.",
                            Titulo = "BARBIE",
                            Trailer = "https://www.youtube.com/watch?v=gH2mRECr6y4&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 12,
                            Genero = 8,
                            Poster = "https://cloudfront-us-east-1.images.arcpublishing.com/abccolor/M7NQTVLP7NDAFJBVWGUG727LS4.jpg",
                            Sinopsis = "Una joven sirena que anhela conocer el mundo que se extiende donde acaba el mar emerge a la superficie y se enamora del príncipe Eric. Sin embargo, la única manera de estar con él exige hacer un pacto con Úrsula, la perversa bruja del mar.",
                            Titulo = "LA SIRENITA",
                            Trailer = "https://www.youtube.com/watch?v=8LECfkm4fJA&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 13,
                            Genero = 10,
                            Poster = "https://mx.web.img3.acsta.net/pictures/19/05/17/09/29/4340950.jpg",
                            Sinopsis = "Ed y Lorraine Warren intentan contener a la muñeca poseída, Annabelle, en una vitrina bendecida. Pero una noche, Annabelle despierta espíritus malignos que se obsesionan con la hija del matrimonio y sus amigos, desatando un evento sobrenatural aterrador.",
                            Titulo = "ANABELLE 3: VUELVE A CASA",
                            Trailer = "https://www.youtube.com/watch?v=KUnKWjeQA9A&ab_channel=WarnerBros.PicturesLatinoam%C3%A9rica"
                        },
                        new
                        {
                            Peliculasid = 14,
                            Genero = 3,
                            Poster = "https://areajugones.sport.es/wp-content/uploads/2021/11/spider-man.jpeg",
                            Sinopsis = "Nuestro héroe héroe es desenmascarado y enfrenta la difícil tarea de equilibrar su vida normal con los riesgos de ser un superhéroe. La ayuda del Doctor Strange aumenta los peligros, llevándolo a explorar el verdadero significado de ser Spider-Man.",
                            Titulo = "SPIDERMAN: SIN CAMINO A CASA",
                            Trailer = "https://www.youtube.com/watch?v=r6t0czGbuGI&ab_channel=SonyPicturesArgentina"
                        },
                        new
                        {
                            Peliculasid = 15,
                            Genero = 1,
                            Poster = "https://cinespainorg.files.wordpress.com/2023/06/screenshot_20230629_203725_twitter.jpg?w=1079",
                            Sinopsis = "Mientras Matt Turner (Liam Neeson) lleva a sus hijos a la escuela, una llamada anónima lo alerta sobre explosivos en su vehículo, desencadenando una frenética carrera contrarreloj con desafíos que desafían su ingenio y valentía para proteger a su familia.",
                            Titulo = "CONTRARRELOJ",
                            Trailer = "https://www.youtube.com/watch?v=VcuXy99TUUo&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 16,
                            Genero = 6,
                            Poster = "https://assets.pikiran-rakyat.com/crop/0x0:0x0/x/photo/2022/07/22/4154057384.jpg",
                            Sinopsis = "Durante la Segunda Guerra Mundial, el teniente general Leslie Groves designa al físico J. Robert Oppenheimer para un grupo de trabajo que está desarrollando el Proyecto Manhattan, cuyo objetivo consiste en fabricar la primera bomba atómica.",
                            Titulo = "OPPENHEIMER",
                            Trailer = "https://www.youtube.com/watch?v=MVvGSBKV504&ab_channel=UniversalPicturesM%C3%A9xico"
                        },
                        new
                        {
                            Peliculasid = 17,
                            Genero = 5,
                            Poster = "https://pics.filmaffinity.com/El_juicio-391136016-mmed.jpg",
                            Sinopsis = "Dos años después del fin de la dictadura militar en Argentina, los principales miembros de la junta son juzgados en los tribunales. Se trata de 18 capítulos sucintamente editados a partir de 530 horas de metraje, dando testimonio del terrorismo de Estado.",
                            Titulo = "EL JUICIO",
                            Trailer = "https://www.youtube.com/watch?v=oLemh24NCEg&ab_channel=Funcinematr%C3%A1ilersyanticipos"
                        },
                        new
                        {
                            Peliculasid = 18,
                            Genero = 7,
                            Poster = "https://pics.filmaffinity.com/Ninja_Turtles_Caos_mutante-917947891-large.jpg",
                            Sinopsis = "Tras pasar años ocultándose, los hermanos tortuga quieren ganarse el corazón de los neoyorquinos con la ayuda de su nueva amiga, April, quien colabora con ellos en la lucha contra unos criminales. Sin embargo, terminan enfrentándose a mutantes.",
                            Titulo = "TORTUGAS NINJA CAOS MUTANTE",
                            Trailer = "https://www.youtube.com/watch?v=VtkTHIXnFXY&ab_channel=SensaCineTRAILERS"
                        },
                        new
                        {
                            Peliculasid = 19,
                            Genero = 6,
                            Poster = "https://pics.filmaffinity.com/Alcarraas-918984157-large.jpg",
                            Sinopsis = "La vida de una familia de cultivadores de melocotones en un pequeño pueblo de Cataluña cambia cuando muere el dueño de su gran finca y su heredero vitalicio decide vender la tierra, amenazando repentinamente su sustento.",
                            Titulo = "ALCARRAS",
                            Trailer = "https://www.youtube.com/watch?v=XacARMle0ZY&ab_channel=Avalon"
                        },
                        new
                        {
                            Peliculasid = 20,
                            Genero = 1,
                            Poster = "https://www.ecartelera.com/carteles/17900/17983/001_m.jpg",
                            Sinopsis = "Un ex agente federal se embarca en una peligrosa misión para salvar a una niña de unos despiadados traficantes de menores. Se le acaba el tiempo y se adentra en la selva colombiana, arriesgando su vida para liberarla de un destino peor que la muerte.",
                            Titulo = "SONIDO DE LIBERTAD",
                            Trailer = "https://www.youtube.com/watch?v=H82uvLvszQ0&ab_channel=CanzionFilms"
                        });
                });

            modelBuilder.Entity("Dominio.Salas", b =>
                {
                    b.Property<int>("SalasId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SalasId"));

                    b.Property<int>("Capacidad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SalasId");

                    b.ToTable("Salas", (string)null);

                    b.HasData(
                        new
                        {
                            SalasId = 1,
                            Capacidad = 5,
                            Nombre = "1"
                        },
                        new
                        {
                            SalasId = 2,
                            Capacidad = 15,
                            Nombre = "2"
                        },
                        new
                        {
                            SalasId = 3,
                            Capacidad = 35,
                            Nombre = "3"
                        });
                });

            modelBuilder.Entity("Dominio.Tickets", b =>
                {
                    b.Property<int>("TicketsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TicketsId"));

                    b.Property<int>("FuncionId")
                        .HasColumnType("int");

                    b.Property<string>("Usuario")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("TicketsId");

                    b.HasIndex("FuncionId");

                    b.HasIndex("TicketsId")
                        .IsUnique();

                    b.ToTable("Tickets", (string)null);
                });

            modelBuilder.Entity("Dominio.Funciones", b =>
                {
                    b.HasOne("Dominio.Peliculas", "Peliculas")
                        .WithMany("Funciones")
                        .HasForeignKey("PeliculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dominio.Salas", "Salas")
                        .WithMany("Funciones")
                        .HasForeignKey("SalaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Peliculas");

                    b.Navigation("Salas");
                });

            modelBuilder.Entity("Dominio.Peliculas", b =>
                {
                    b.HasOne("Dominio.Generos", "Generos")
                        .WithMany("Peliculas")
                        .HasForeignKey("Genero")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Generos");
                });

            modelBuilder.Entity("Dominio.Tickets", b =>
                {
                    b.HasOne("Dominio.Funciones", "Funciones")
                        .WithMany("Tickets")
                        .HasForeignKey("FuncionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Dominio.Funciones", b =>
                {
                    b.Navigation("Tickets");
                });

            modelBuilder.Entity("Dominio.Generos", b =>
                {
                    b.Navigation("Peliculas");
                });

            modelBuilder.Entity("Dominio.Peliculas", b =>
                {
                    b.Navigation("Funciones");
                });

            modelBuilder.Entity("Dominio.Salas", b =>
                {
                    b.Navigation("Funciones");
                });
#pragma warning restore 612, 618
        }
    }
}
