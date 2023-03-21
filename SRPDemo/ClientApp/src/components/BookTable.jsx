import React from 'react';
import DataTable from 'react-data-table-component';


const BookTable = (props) => {
    const data = props.data
    const columns = [
        {
            name: 'Book Title',
            selector: row => row.title,
        },
        {
            name: 'Author',
            selector: row => row.author,
        },
        {
            name: 'Link to Open Library Page',
            selector: row => <a href={row.link}>Go to book page</a>,
        }
    ];

    return (
        <DataTable
            pagination
            columns={columns}
            data={data}
        />
    );
}

//const SearchBar = () => {
//    return (
//        <div>
//            <h1>Search</h1>
//        </div>
//        )
//}

export default BookTable;