-- Table: public.exams

-- DROP TABLE IF EXISTS public.exams;

CREATE TABLE IF NOT EXISTS public.exams
(
    id bigint NOT NULL DEFAULT nextval('exams_id_seq'::regclass),
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT exams_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.exams
    OWNER to postgres;