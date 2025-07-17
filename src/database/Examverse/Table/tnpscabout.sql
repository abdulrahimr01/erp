-- Table: public.tnpscabout

-- DROP TABLE IF EXISTS public.tnpscabout;

CREATE TABLE IF NOT EXISTS public.tnpscabout
(
    id bigint NOT NULL DEFAULT nextval('tnpscabout_id_seq'::regclass),
    text character varying(500) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT tnpscabout_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.tnpscabout
    OWNER to postgres;