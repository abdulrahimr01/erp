-- Table: public.roles

-- DROP TABLE IF EXISTS public.roles;

CREATE TABLE IF NOT EXISTS public.roles
(
    id bigint NOT NULL GENERATED ALWAYS AS IDENTITY ( INCREMENT 1 START 1 MINVALUE 1 MAXVALUE 9223372036854775807 CACHE 1 ),
    name character varying(100) COLLATE pg_catalog."default" NOT NULL,
    notes character varying(200) COLLATE pg_catalog."default",
    isactive boolean NOT NULL,
    roleid bigint,
    CONSTRAINT roles_pkey PRIMARY KEY (id),
    CONSTRAINT name_ukey UNIQUE (name)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.roles
    OWNER to postgres;