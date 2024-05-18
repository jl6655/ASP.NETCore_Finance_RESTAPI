import React from 'react'
import Table from '../../Components/Table/Table'

type Props = {}

const DesignPage = (props: Props) => {
  return (
    <>
    <h1>Finshark Design Page</h1>
    <h2>
        This is Finshark's design page. This is where we will house various design aspects of the app.
    </h2>
    {/*
        Design page is meant to be a centralized place that houses reusable components within the app and provides information on how they function - akin to a simple 'wiki'
    */}
    <Table />
    </>
  )
}

export default DesignPage