import React, { useState } from 'react';
import BookTable from './BookTable';
import SearchBar from './SearchBar'; 

const Library = (props) => {

    const [books, setBooks] = useState([]);

    function searchBarChange(e) {
        populateBookData(e)
    }
     
    async function populateBookData(e) {
        const response = await fetch('/api/v1/LibrarySearch/search?title=' + e);
        const data = await response.json();
        setBooks(data);
    }

    return (
        <div>
            <h1>Library Search</h1>
            <div>
                <label className="label">Enter Book Name</label><SearchBar onChange={searchBarChange}></SearchBar>
            </div>
            <BookTable data={books}></BookTable>
        </div>
    );
}

export default Library;