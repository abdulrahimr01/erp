-- Table: public.coursevideos

-- DROP TABLE IF EXISTS public.coursevideos;

CREATE TABLE IF NOT EXISTS public.coursevideos
(
    id bigint NOT NULL DEFAULT nextval('coursevideos_id_seq'::regclass),
    coursename character varying(100) COLLATE pg_catalog."default" NOT NULL,
    title character varying(50) COLLATE pg_catalog."default" NOT NULL,
    youtubevideoid character varying(50) COLLATE pg_catalog."default" NOT NULL,
    description character varying(500) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT coursevideos_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.coursevideos
    OWNER to postgres;