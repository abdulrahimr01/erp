-- Table: public.supplier

-- DROP TABLE IF EXISTS public.supplier;

CREATE TABLE IF NOT EXISTS public.supplier
(
    id integer NOT NULL DEFAULT nextval('supplier_id_seq'::regclass),
    typeid character varying(50) COLLATE pg_catalog."default",
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    gst character varying(20) COLLATE pg_catalog."default" NOT NULL,
    landline character varying(20) COLLATE pg_catalog."default",
    email character varying(50) COLLATE pg_catalog."default" NOT NULL,
    contact character varying(50) COLLATE pg_catalog."default" NOT NULL,
    mobile character varying(15) COLLATE pg_catalog."default" NOT NULL,
    address character varying(50) COLLATE pg_catalog."default",
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    CONSTRAINT supplier_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.supplier
    OWNER to postgres;