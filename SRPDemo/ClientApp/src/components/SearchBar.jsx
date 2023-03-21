import { useState, useMemo, useEffect } from "react";
import debouce from "lodash.debounce";

const SearchBar = ({ keyword, onChange }) => {
    const BarStyle = { width: "20rem", background: "#F0F0F0", border: "none", padding: "0.5rem" };
    const [searchTerm, setSearchTerm] = useState("");

    const handleChange = (e) => {
        setSearchTerm(e.target.value);
        onChange(e.target.value);
    };

    const debouncedResults = useMemo(() => {
        return debouce(handleChange, 1000);
    }, []);

    useEffect(() => {
        return () => {
            debouncedResults.cancel();
        };
    });

    return (
            <input
                style={BarStyle}
                key="search-bar"
                value={keyword}
                placeholder={"Search books"}
                onChange={debouncedResults}
            />
    );
}

export default SearchBar;