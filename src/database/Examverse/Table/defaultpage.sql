-- Table: public.defaultpage

-- DROP TABLE IF EXISTS public.defaultpage;

CREATE TABLE IF NOT EXISTS public.defaultpage
(
    id integer NOT NULL DEFAULT nextval('defaultpage_id_seq'::regclass),
    pagename character varying(50) COLLATE pg_catalog."default" NOT NULL,
    pagepath character varying(100) COLLATE pg_catalog."default" NOT NULL,
    label character varying(100) COLLATE pg_catalog."default" NOT NULL,
    icon character varying(100) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT defaultpage_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.defaultpage
    OWNER to postgres;