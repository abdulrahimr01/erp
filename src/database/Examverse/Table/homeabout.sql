-- Table: public.homeabout

-- DROP TABLE IF EXISTS public.homeabout;

CREATE TABLE IF NOT EXISTS public.homeabout
(
    id bigint NOT NULL DEFAULT nextval('homeabout_id_seq'::regclass),
    text character varying(500) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT homeabout_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.homeabout
    OWNER to postgres;