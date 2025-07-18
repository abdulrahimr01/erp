-- Table: public.menu

-- DROP TABLE IF EXISTS public.menu;

CREATE TABLE IF NOT EXISTS public.menu
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    menuname character varying(50) COLLATE pg_catalog."default" NOT NULL,
    submenuname character varying(50) COLLATE pg_catalog."default" NOT NULL,
    menupath character varying(100) COLLATE pg_catalog."default" NOT NULL,
    submenupath character varying(100) COLLATE pg_catalog."default" NOT NULL,
    icon character varying(100) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT menu_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.menu
    OWNER to postgres;