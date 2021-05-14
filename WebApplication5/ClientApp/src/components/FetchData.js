import React, { Component } from 'react';



export class FetchData extends Component {
    static displayName = FetchData.name;
   

    constructor(props) {
        super(props);
        this.state = { forecasts: [], loading: true, viewindex: 0, viewcount: 8 };
        this.countChange = this.countChange.bind(this);
    }

    componentDidMount() {
        this.populateWeatherData();
    }
    handleClick = async (i) => {

        const response = await fetch('weatherforecast/Take20?index=' + i + '&count=' + this.state.viewcount);
        const data = await response.json();
        console.log(data);
        this.setState({ forecasts: data, loading: false, viewindex: i });


    };

    nextPage(i) {
        this.handleClick(i);
    }

    prevPage(i) {
        this.handleClick(i<0?0:i);
    }

    countChange(e) {
        this.setState({
            viewcount: e.target.value
        });
    }

   renderForecastsTable(forecasts) {
       return (
           <>
               <h3>{forecasts.length + " entries; index" + this.state.viewindex}</h3>
               <button id="btn" onClick={() => this.prevPage(this.state.viewindex - this.state.viewcount)}>Prev</button>
               <button id="btn" onClick={() => this.nextPage(this.state.viewindex + Number(this.state.viewcount))}>Next </button>
               <input type="number" onChange={this.countChange} value={this.state.viewcount}></input>
               <form method="POST" encType="multipart/form-data" action="weatherforecast/upload" >

                  <input name="_files" type="file" multiple/>
                  <input type="submit" value="Upload"/>
               </form>

               <form method="POST"  action="weatherforecast/mpost" >

                   <input name="form" placeholder="456" type="text" />
                   <input type="submit" value="Upload" />
               </form>
      
          <table className='table table-striped' aria-labelledby="tabelLabel">
             
             
        <thead>
          <tr>
            <th>ID</th>
            <th>Name</th>
            <th>Path</th>
            <th>Image</th>
            
          </tr>
        </thead>
            <tbody>
                {console.log(forecasts)}
                
                {forecasts.map(forecast =>

                    <tr key={forecast.id}>
                        <td>{forecast.id}</td>
                        <td>{forecast.name}</td>
                        <td>{forecast.path}</td>
                        <td><img src={forecast.path} alt="cannot download" height="60px" /></td>
                   
            </tr>
          )}
        </tbody>
               </table>
               </>
    );
  }

  render() {
    let contents = this.state.loading ? <p><em>Loading...</em></p> : this.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

   

    async populateWeatherData() {

        this.nextPage(0);
   // this.setState({ forecasts: data, loading: false });
  }
}
