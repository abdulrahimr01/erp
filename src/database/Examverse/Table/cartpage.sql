-- Table: public.cartpage

-- DROP TABLE IF EXISTS public.cartpage;

CREATE TABLE IF NOT EXISTS public.cartpage
(
    id bigint NOT NULL DEFAULT nextval('cartpage_id_seq'::regclass),
    userid bigint NOT NULL,
    productid bigint NOT NULL,
    quantity integer NOT NULL DEFAULT 1,
    price numeric(10,2) NOT NULL,
    originalprice numeric(10,2) NOT NULL,
    isactive boolean NOT NULL,
    actionby character varying(50) COLLATE pg_catalog."default" NOT NULL,
    actiondate timestamp without time zone NOT NULL,
    CONSTRAINT cartpage_pkey PRIMARY KEY (id)
)

TABLESPACE pg_default;

ALTER TABLE IF EXISTS public.cartpage
    OWNER to postgres;