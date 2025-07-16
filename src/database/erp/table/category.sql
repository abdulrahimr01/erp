-- Table: public.category

-- DROP TABLE IF EXISTS public.category;

CREATE TABLE IF NOT EXISTS public.category
(
    id integer NOT NULL DEFAULT nextval('category_id_seq'::regclass),
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    notes character varying(200) COLLATE pg_catalog."default",
    actionby character varying(50) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    CONSTRAINT category_pk PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.category
    OWNER to postgres;