-- Table: public.about

-- DROP TABLE IF EXISTS public.about;

CREATE TABLE IF NOT EXISTS public.about
(
    id bigint NOT NULL DEFAULT nextval('about_id_seq'::regclass),
    type character varying(50) COLLATE pg_catalog."default" NOT NULL,
    content character varying COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT about_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.about
    OWNER to postgres;