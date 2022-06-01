const evaluate = (currentDate, res) => {
    const expectedStatus = (currentDate.ok)? 200 : 400;
    const expectedBody = (currentDate.ok)? "stat" : "errors";

    pm.test(`Status is ${expectedStatus}`, () => {
        pm.expect(res.code).to.equal(expectedStatus);
    });
    pm.test(`Body contains ${expectedBody}`, () => {
        pm.expect(res.json()).to.have.property(expectedBody)
    });
}

// Evaluate current call
const currentDate = pm.environment.get("[GET]-Use of the app-Current date");
evaluate(currentDate, pm.response);

// Evaluate rest of calls
const dates = pm.environment.get("[GET]-Use of the app-Dates");
const host = pm.environment.get("host");
const token = pm.environment.get("token");

dates.map(currentDate => 
{
    const request = {
        url: `${host}/api/stats/use-of-the-app?Year=${currentDate.year}&Month=${currentDate.month}`,
        method: 'GET',
        header: {
            'Authorization': `Bearer ${token}`
        }
    };

    pm.sendRequest(request, (err, res) => {
        evaluate(currentDate, res);
    });
})

// Clean environment
pm.environment.unset("[GET]-Use of the app-Dates");
pm.environment.unset("[GET]-Use of the app-Current date");
pm.environment.unset("[GET]-Use of the app-Year");
pm.environment.unset("[GET]-Use of the app-Month");

