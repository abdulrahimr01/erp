-- Table: public.role

-- DROP TABLE IF EXISTS public.role;

CREATE TABLE IF NOT EXISTS public.role
(
    id bigint NOT NULL DEFAULT nextval('role_id_seq'::regclass),
    name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    notes character varying(200) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    actionby character varying(100) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT role_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.role
    OWNER to postgres;