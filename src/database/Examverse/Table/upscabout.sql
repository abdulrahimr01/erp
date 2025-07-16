-- Table: public.upscabout

-- DROP TABLE IF EXISTS public.upscabout;

CREATE TABLE IF NOT EXISTS public.upscabout
(
    id integer NOT NULL DEFAULT nextval('upscabout_id_seq'::regclass),
    text character varying(500) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT upscabout_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.upscabout
    OWNER to postgres;