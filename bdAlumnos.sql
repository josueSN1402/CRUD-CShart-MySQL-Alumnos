create database bdalumnos;
use bdalumnos;

CREATE TABLE alumnos (
  id INT NOT NULL AUTO_INCREMENT,
  codigo VARCHAR(10) NOT NULL,
  nombre VARCHAR(20) NOT NULL,
  apa VARCHAR(30) NULL,
  ama VARCHAR(30) NULL,
  anotacion VARCHAR(150) NULL,
  nota1 INT NULL,
  nota2 INT NULL,
  nota3 INT NULL,
  PRIMARY KEY (id),
  UNIQUE INDEX codigo_UNIQUE (`codigo` ASC) VISIBLE
);
