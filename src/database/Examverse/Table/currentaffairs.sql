-- Table: public.currentaffairs

-- DROP TABLE IF EXISTS public.currentaffairs;

CREATE TABLE IF NOT EXISTS public.currentaffairs
(
    id bigint NOT NULL DEFAULT nextval('currentaffairs_id_seq'::regclass),
    date timestamp without time zone NOT NULL,
    catagory character varying COLLATE pg_catalog."default" NOT NULL,
    slug character varying COLLATE pg_catalog."default" NOT NULL,
    content character varying COLLATE pg_catalog."default" NOT NULL,
    created_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    updated_at timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    title character varying(100) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT currentaffairs_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.currentaffairs
    OWNER to postgres;