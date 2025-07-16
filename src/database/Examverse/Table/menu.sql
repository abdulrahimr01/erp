-- Table: public.menu

-- DROP TABLE IF EXISTS public.menu;

CREATE TABLE IF NOT EXISTS public.menu
(
    id integer NOT NULL DEFAULT nextval('menu_id_seq'::regclass),
    menuname character varying(50) COLLATE pg_catalog."default" NOT NULL,
    submenuname character varying(50) COLLATE pg_catalog."default" NOT NULL,
    icon character varying(100) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    menupath character varying(100) COLLATE pg_catalog."default",
    submenupath character varying(100) COLLATE pg_catalog."default",
    CONSTRAINT menu_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.menu
    OWNER to postgres;