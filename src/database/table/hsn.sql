-- Table: public.hsn

-- DROP TABLE IF EXISTS public.hsn;

CREATE TABLE IF NOT EXISTS public.hsn
(
    id integer NOT NULL DEFAULT nextval('hsn_id_seq'::regclass),
    categoryid character varying(50) COLLATE pg_catalog."default",
    name character varying(50) COLLATE pg_catalog."default" NOT NULL,
    notes character varying(200) COLLATE pg_catalog."default",
    gst character varying(20) COLLATE pg_catalog."default" NOT NULL,
    sgst character varying(20) COLLATE pg_catalog."default" NOT NULL,
    cgst character varying(20) COLLATE pg_catalog."default" NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    isactive boolean NOT NULL,
    CONSTRAINT hsn_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.hsn
    OWNER to postgres;