-- PROCEDURE: public.sp_books(character varying, character varying, character varying, numeric, numeric, character varying, character varying, integer, boolean, character varying, timestamp without time zone, bytea, bytea, character varying, bigint)

-- DROP PROCEDURE IF EXISTS public.sp_books(character varying, character varying, character varying, numeric, numeric, character varying, character varying, integer, boolean, character varying, timestamp without time zone, bytea, bytea, character varying, bigint);

CREATE OR REPLACE PROCEDURE public.sp_books(
	IN p_title character varying,
	IN p_examname character varying,
	IN p_author character varying,
	IN p_price numeric,
	IN p_originalprice numeric,
	IN p_description character varying,
	IN p_details character varying,
	IN p_stocks integer,
	IN p_isactive boolean,
	IN p_actionby character varying,
	IN p_actiondate timestamp without time zone,
	IN p_frontimage bytea,
	IN p_backimage bytea,
	IN p_course character varying,
	IN p_id bigint DEFAULT 0)
LANGUAGE 'plpgsql'
AS $BODY$
BEGIN
    -- Insert
    IF p_id = 0 THEN
        INSERT INTO books(
            title, examname, author, price, originalprice, description, details, stocks, 
            isactive, actionby, actiondate, frontimage, backimage, course
        )
        VALUES(
            p_title, p_examname, p_author, p_price, p_originalprice, p_description, p_details, p_stocks, 
            p_isactive, p_actionby, p_actiondate, p_frontimage, p_backimage, p_course
        );
    END IF;

    -- Update
    IF p_id > 0 AND EXISTS (SELECT 1 FROM books WHERE id = p_id) THEN
        UPDATE books
        SET 
            title = p_title,
            examname = p_examname,
            author = p_author,
            price = p_price,
            originalprice = p_originalprice,
            description = p_description,
            details = p_details,
            stocks = p_stocks,
            isactive = p_isactive,
            actionby = p_actionby,
            actiondate = p_actiondate,
            frontimage = p_frontimage,
            backimage = p_backimage,
            course = p_course
        WHERE id = p_id;
    END IF;
END;
$BODY$;
ALTER PROCEDURE public.sp_books(character varying, character varying, character varying, numeric, numeric, character varying, character varying, integer, boolean, character varying, timestamp without time zone, bytea, bytea, character varying, bigint)
    OWNER TO postgres;
