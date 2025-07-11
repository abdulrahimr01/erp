-- Table: public.businesstype

-- DROP TABLE IF EXISTS public.businesstype;

CREATE TABLE IF NOT EXISTS public.businesstype
(
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    notes character varying(200) COLLATE pg_catalog."default",
    actionby character varying(50) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    id integer NOT NULL DEFAULT nextval('businesstype_id_seq'::regclass),
    CONSTRAINT businesstype_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.businesstype
    OWNER to postgres;