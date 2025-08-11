-- Table: public.editorials

-- DROP TABLE IF EXISTS public.editorials;

CREATE TABLE IF NOT EXISTS public.editorials
(
    id bigint NOT NULL DEFAULT nextval('editorials_id_seq'::regclass),
    date timestamp without time zone NOT NULL,
    category character varying COLLATE pg_catalog."default" NOT NULL,
    title character varying(100) COLLATE pg_catalog."default" NOT NULL,
    slug character varying COLLATE pg_catalog."default" NOT NULL,
    content character varying COLLATE pg_catalog."default" NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT editorials_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.editorials
    OWNER to postgres;