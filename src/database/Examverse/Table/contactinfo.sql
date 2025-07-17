-- Table: public.contactinfo

-- DROP TABLE IF EXISTS public.contactinfo;

CREATE TABLE IF NOT EXISTS public.contactinfo
(
    id bigint NOT NULL DEFAULT nextval('contactinfo_id_seq'::regclass),
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    details character varying(100) COLLATE pg_catalog."default" NOT NULL,
    color character varying(20) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT contactinfo_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.contactinfo
    OWNER to postgres;