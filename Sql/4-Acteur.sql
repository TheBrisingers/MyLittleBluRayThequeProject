-- Table: BluRayTheque.Acteur

-- DROP TABLE IF EXISTS "BluRayTheque"."Acteur";

CREATE TABLE IF NOT EXISTS "BluRayTheque"."Acteur"
(
    "Id" integer NOT NULL DEFAULT nextval('"BluRayTheque"."Acteur_Id_seq"'::regclass),
    "IdBluRay" integer NOT NULL,
    "IdActeur" integer NOT NULL,
    CONSTRAINT "Acteur_pkey" PRIMARY KEY ("IdBluRay"),
    CONSTRAINT "ActeurIdBluRay" FOREIGN KEY ("IdBluRay")
        REFERENCES "BluRayTheque"."BluRay" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT "ActeurIdPersonne" FOREIGN KEY ("IdActeur")
        REFERENCES "BluRayTheque"."Personne" ("Id") MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS "BluRayTheque"."Acteur"
    OWNER to postgres;