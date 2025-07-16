-- Table: public.papers

-- DROP TABLE IF EXISTS public.papers;

CREATE TABLE IF NOT EXISTS public.papers
(
    id integer NOT NULL DEFAULT nextval('papers_id_seq'::regclass),
    exam character varying(50) COLLATE pg_catalog."default" NOT NULL,
    name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT papers_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.papers
    OWNER to postgres;